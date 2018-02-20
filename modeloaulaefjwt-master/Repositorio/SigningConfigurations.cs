using Microsoft.IdentityModel.Tokens;

namespace modeloaulaefjwt_master.Repositorio {
    public class SigningConfigurations {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations () {
            using (var provider = new System.Security.Cryptography.RSACryptoServiceProvider (2048)) {
                Key = new RsaSecurityKey (provider.ExportParameters (true));
            }

            SigningCredentials = new SigningCredentials (Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}