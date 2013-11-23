﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MasterMind.Filters;
using MasterMind.Models;
using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Implementacao;
using FluentNHibernate.Mapping;
using Infraestrutura.Repositorios.Entidades.DTO;
using System.Drawing;

namespace MasterMind.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {              
            if (ModelState.IsValid && WebSecurity.Login(model.email, model.Senha, persistCookie: model.RememberMe))
            {
                GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
                Usuario aux = repositorio.ObterPorId(WebSecurity.GetUserId(model.email));                
                
                if (aux.Id_perfil == 2){
                return RedirectToAction("Principal", "Game");
                }
                else if (aux.Id_perfil == 1)
                {
                    return RedirectToAction("Index", "BackOffice");
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "O usuário ou senha está incorreto!");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.ListaSexo = SexoDTO.ListaSexo();
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Usuario model)
        {
            ViewBag.ListaSexo = SexoDTO.ListaSexo();
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    GenericoRep<Usuario> repositorio = new GenericoRep<Usuario>();
                    repositorio.Salvar(model);
                    Usuario auxcadastro = repositorio.ObterPorId(model.Id_user);

                    if (auxcadastro != null)
                    {
                        WebSecurity.CreateAccount(model.Email, model.Senha);
                        WebSecurity.Login(model.Email, model.Senha);
                    }
                   
                    return RedirectToAction("Principal", "Game");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.ListaSexo = SexoDTO.ListaSexo();

            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Sua senha foi alterada."
                : message == ManageMessageId.SetPasswordSuccess ? "Senha salva com sucesso."
                : message == ManageMessageId.RemoveLoginSuccess ? "O login externo foi removido."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");

            GenericoRep<Manage> repositorio = new GenericoRep<Manage>();
            Manage aux = repositorio.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));

            return View(aux);
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(Manage model)
        {
            ViewBag.ListaSexo = SexoDTO.ListaSexo();

            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");

            GenericoRep<Usuario> auxUsu = new GenericoRep<Usuario>();
            IEnumerable<Usuario> lauxUsu = auxUsu.ObterTodos().Where(x => x.Email == model.Email);

            if ((lauxUsu.Count() > 0) && (lauxUsu.ElementAt(0).Id_user != model.Id_user))
            {
                ModelState.AddModelError("Usuário", "Já existe este e-mail cadastrado para outro usuário!");
                return View(model);            
            }

            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded = false;

                    HttpPostedFileBase imagem = Request.Files["photo"];

                    if ((imagem != null) && (imagem.FileName != ""))
                    {
                        if (imagem.ContentLength > 100240)
                        {
                            ModelState.AddModelError("photo", "O tamanho da foto não pode exceder 100 KB");
                            return View(model);
                        }

                        var supportedTypes = new[] { "jpg", "jpeg", "png" };

                        var fileExt = System.IO.Path.GetExtension(imagem.FileName).Substring(1);

                        if (!supportedTypes.Contains(fileExt))
                        {
                            ModelState.AddModelError("photo", "Tipo inválido. Somente os tipos (jpg, jpeg, png) são suportados.");
                            return View(model);
                        }

                        string arquivo = System.IO.Path.Combine(
                                                   Server.MapPath("~/img/usuarios"), model.Id_user+"."+fileExt);

                        imagem.SaveAs(arquivo);
                        model.imagem = "../../img/usuarios/"+ model.Id_user + "." + fileExt;
                    }

                    try
                    {
                        GenericoRep<Manage> repositorio = new GenericoRep<Manage>();
                        repositorio.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));

                        if (model.Senha != null)
                            changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.Senha);
                        else
                        {
                            model.Senha = model.OldPassword;
                            model.ConfirmPassword = model.OldPassword;
                        }

                        repositorio.Salvar(model);
                        changePasswordSucceeded = true;
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = "Cadastro alterado com sucesso" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "A senha atual está incorreta ou a nova senha é inválida.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.Senha);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Este e-mail já está cadastrado para um usuário.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Este e-mail já está cadastrado para um usuário.";

                case MembershipCreateStatus.InvalidPassword:
                    return "A senha é inválida.";

                case MembershipCreateStatus.InvalidEmail:
                    return "O e-mail indicado é inválido.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "A resposta referente à pergunta da senha é inválida.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "A pergunta da senha é inválida.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Nome de usuário inválido";

                case MembershipCreateStatus.ProviderError:
                    return "A autenticação retornou um erro. Tente novamente.";

                case MembershipCreateStatus.UserRejected:
                    return "A Criação de usuário novo foi cancelada.";

                default:
                    return "Ocorreu um erro desconhecido.";
            }
        }
        #endregion
    }
}
