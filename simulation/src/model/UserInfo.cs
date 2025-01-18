namespace simulation.src.model {

    /// <summary>
    /// Informacoes do usuario
    /// </summary>
    /// <param name="user">Nome do usuario</param>
    /// <param name="password">Senha do usuario</param>
    public class UserInfo(string user, string password) {
        
        /// <summary>
        /// Variável privada para o nome do usuário
        /// </summary>
        private string _user = user;

        /// <summary>
        /// Variável privada para a senha do usuário
        /// </summary>
        private string _password = password;
                
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
                return cryptPassword(this._password);
            }

            /// <summary>
            /// Atualiza a senha do usuário
            /// </summary>
            set {
                this._password = value;
            }
        }

        /// <summary>
        /// Metodo privado para encriptar a senha do usuario
        /// </summary>
        /// <param name="password">Senha a ser encriptada</param>
        /// <returns>Nova senha encriptada</returns>
        private static string cryptPassword(string password){
            char[] cryptArray = password.ToCharArray();
            Array.Reverse(cryptArray);

            string crypt = new string(cryptArray);
            return $"HASH{crypt}000";
        }
    }
}