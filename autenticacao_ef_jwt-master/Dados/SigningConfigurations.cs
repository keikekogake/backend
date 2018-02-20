using Microsoft.IdentityModel.Tokens;

namespace Autenticacao_EF_JWT.Dados
{
    /*
        A propriedade Key, à qual será vinculada uma instância da classe SecurityKey (namespace Microsoft.IdentityModel.Tokens) armazenando a chave de criptografia utilizada na criação de tokens;
        A propriedade SigningCredentials, que receberá um objeto baseado em uma classe também chamada SigningCredentials (namespace Microsoft.IdentityModel.Tokens). Esta referência conterá a chave de criptografia e o algoritmo de segurança empregados na geração de assinaturas digitais para tokens;
        Um construtor responsável pela inicialização das propriedades Key e SigningCredentials. Este elemento fará uso para isto dos tipos RSACryptoServiceProvider (namespace System.Security.Cryptography), RsaSecurityKey (namespace Microsoft.IdentityModel.Tokens) e SecurityAlgorithms (namespace Microsoft.IdentityModel.Tokens), determinando assim o uso do padrão RSA como algoritmo de criptografia usado na produção de tokens.
     */
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new System.Security.Cryptography.RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
}
    }
}