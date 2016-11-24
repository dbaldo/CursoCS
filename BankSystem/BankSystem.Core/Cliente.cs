namespace BankSystem.Core
{
    public class Cliente
    {
        public enum TipoDocumento { CPF, CNPJ }
        public enum TipoPessoa { Fisica, Juridica }

        public TipoDocumento TipoDoc
        {
            get;
            set;
        }

        public string NumeroDoc
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

    }
}