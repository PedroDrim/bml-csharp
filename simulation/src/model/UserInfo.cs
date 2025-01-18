using simulation.src.model.exception;

namespace simulation.src.model {

    /// <summary>
    /// Informacoes do usuario
    /// </summary>
    /// <param name="user">Nome do usuario</param>
    /// <param name="password">Senha do usuario</param>
    /// <param name="credit">Quantidade de creditos do usuario</param>
    public class UserInfo(string user, string password, double credit) {
        
        private string _password = password ?? throw new InvalidParameterException("'password' e null");

        /// <summary>
        /// Nome do usuario
        /// </summary>
        /// <returns>Nome do usuario</returns>
        public string User { get; set; } = user ?? throw new InvalidParameterException("'user' e null");

        /// <summary>
        /// Quantidade de creditos do usuario
        /// </summary>
        /// <returns>Quantidade de creditos do usuario</returns>
        public double Credit { get; set; } = credit;

        /// <summary>
        /// Senha do usuario
        /// </summary>
        /// <returns>Senha do usuario criptografada</returns>
        public string Password {
            get {
                return CryptPassword(this._password);
            }

            set {
                this._password = value ?? throw new InvalidParameterException("'password' e null");
            }
        }

        /// <summary>
        /// Metodo privado para encriptar a senha do usuario
        /// </summary>
        /// <param name="password">Senha a ser encriptada</param>
        /// <returns>Nova senha encriptada</returns>
        private string CryptPassword(string password){
            if(password == null) throw new InvalidParameterException("'password' e null");

            char[] cryptArray = password.ToCharArray();
            Array.Reverse(cryptArray);

            string crypt = new(cryptArray);
            return $"HASH{crypt}000";
        }
    }
}