## Azure Function KeyVault Bindings
### This is a prototype being actively worked on - Use at your own Risk

This repo is built to show how KeyVault bindings can be added using dotNet core into the Azure Functions 2.0 Runtime

Lots of this work was inspired from [the offical documentation](https://github.com/Azure/azure-webjobs-sdk/wiki/Creating-custom-input-and-output-bindings)

The aim of this project is to add a binding into the function.json file like:

```json
{
  "type": "keyvault",
  "direction": "in",
  "secretUrl": "https://my_custom_keyvault.vault.azure.net/secrets/secret1",
  "name": "thesecret"
}
```

to retrieve secret1 from your KeyVault Instance. This can then be accessed in your function using the binding name:

```ecmascript 6
module.exports = function (context, req, thesecret) {
    context.log('Secret value is... ' + thesecret);

    context.done();
};
```

This secret would then be available for the lifetime of the function.

### Current Tasks being worked on
- How to install extensions into the runtime on azure
- Exception handling
- Is there a native AAD Token library that uses dotNet Core
- extensions.json isn't reliably created on many machines when installing an extension (this is some sort of bug in `func extensions sync` which is called under the hood by `func extensions install`)
- Finishing the prototype so it actually returns a secret
