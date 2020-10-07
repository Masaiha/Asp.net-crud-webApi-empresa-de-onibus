using System;
using System.Collections.Generic;
using System.Text;

namespace Ubus.Business.Validations.ErrorMessages
{
    public static class MessagesFluentValidation
    {
        public const string NotEmpty = "O campo {PropertyName} precisa ser fornecido.";
        public const string Length = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.";
        public const string CpfLength = "O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.";
        public const string CpfInvalid = "CPF inválido";
    }
}
