using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace KeyVaultSecretsBinding
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter)]
    public class KeyVaultBindingAttribute : Attribute
    {
        public string secretUrl { get; set; }
    }

    public class KeyVaultItem
    {
        public string name { get; set; }
    }

    public class KeyVaultSecret : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddConverter<KeyVaultItem, string>(ConvertToString);
            context.AddConverter<string, KeyVaultItem>(ConvertToKeyVaultItem);

            var rule = context.AddBindingRule<KeyVaultBindingAttribute>();
            rule.BindToInput<KeyVaultItem>(BuildItemFromAttr);


        }

        private string ConvertToString(KeyVaultItem item)
        {
            return item.name;
        }

        private KeyVaultItem ConvertToKeyVaultItem(string arg)
        {
            return new KeyVaultItem
            {
                name = arg

            };
        }

        private KeyVaultItem BuildItemFromAttr(KeyVaultBindingAttribute attr)
        {
            return new KeyVaultItem
            {
                // TODO: add stuff here
                // 
                name = attr.secretUrl
            };
        }
    }
}
