using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using STP.Business.Interfaces;
using STP.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STP.Interface.Controllers.Common
{
    public class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;
        //public readonly IUser _appUser;

        protected Guid UsuarioId { get; }
        protected bool UsuarioAutenticado { get; }

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
            //_appUser = appUser;

            //if (appUser.IsAuthenticated())
            //{
            //    UsuarioId = appUser.GetUserId();
            //    UsuarioAutenticado = true;
            //}
        }

        // Validação de notificações de erro
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(x => x.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        // Validação  de ModelState
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var mensagemErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(mensagemErro);
            }
        }

        protected void NotificarErro(string mensagemErro)
        {
            _notificador.Handle(new Notificacao(mensagemErro));
        }

        // Validação operação de negocio
    }
}
