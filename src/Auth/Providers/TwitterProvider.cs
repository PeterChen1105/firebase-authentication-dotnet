﻿namespace Firebase.Auth.Providers
{
    public class TwitterProvider : OAuthProvider
    {
        public static AuthCredential GetCredential(string token, string secret)
        {
            return new TwitterCredential
            {
                ProviderType = FirebaseProviderType.Twitter,
                Token = token,
                Secret = secret
            };
        }

        public override FirebaseProviderType ProviderType => FirebaseProviderType.Twitter;

        protected override string LocaleParameterName => "lang";

        internal class TwitterCredential : OAuthCredential
        {
            public string Secret { get; set; }

            internal override string GetPostBodyValue(FirebaseProviderType ProviderType)
            {
                return $"{base.GetPostBodyValue(ProviderType)}&oauth_token_secret={this.Secret}";
            }
        }
    }
}
