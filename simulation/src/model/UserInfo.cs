namespace simulation.src.model {

    /// <summary>
    /// Classe contendo as informacoes do usuario
    /// </summary>
    /// <param name="user">Nome do usuario</param>
    /// <param name="password">Senha do usuario</param>
    /// <param name="credit">Credito do usuario</param>
    public class UserInfo(string user, string password, double credit) {
        
        /// <summary>
        /// Variável privada para o nome do usuário
        /// </summary>
        private string _user = user;

        /// <summary>
        /// Variável privada para a senha do usuário
        /// </summary>
        private string _password = password;

        /// <summary>
        /// Variável privada para os creditos do usuário
        /// </summary>
        private double _credit = credit;
                
        /// <summary>
        /// Variável publica para o nome do usuário
        /// </summary>
        public string User {

            /// <summary>
            /// Obtem o nome do usuario
            /// </summary>
            /// <returns>Nome do usuario</returns>
            get {
                return this._user;
            }

            /// <summary>
            /// Atualiza o nome do usuário
            /// </summary>
            set {
                this._user = value;
            }
        }

        /// <summary>
        /// Variável publica para a senha do usuário
        /// </summary>
        public string Password {
            
            /// <summary>
            /// Obtem a senha do usuario criptografada
            /// </summary>
            /// <returns>Senha do usuario criptografada</returns>
            get {
                return this.CryptPassword(this._password);
            }

            /// <summary>
            /// Atualiza a senha do usuário
            /// </summary>
            set {
                this._password = value;
            }
        }

        /// <summary>
        /// Variável publica para o credito do usuário
        /// </summary>
        public double Credit {

            /// <summary>
            /// Obtem o credito do usuario
            /// </summary>
            /// <returns>credito do usuario</returns>
            get {
                return this._credit;
            }

            /// <summary>
            /// Atualiza o nome do usuário
            /// </summary>
            set {
                this._credit = value;
            }
        }

        /// <summary>
        /// Metodo privado para encriptar a senha do usuario
        /// </summary>
        /// <param name="password">Senha a ser encriptada</param>
        /// <returns>Nova senha encriptada</returns>
        private string CryptPassword(string password) {
            char[] cryptArray = password.ToCharArray();
            Array.Reverse(cryptArray);

            string crypt = new string(cryptArray);
            return $"HASH{crypt}000";
        }
    }
}
