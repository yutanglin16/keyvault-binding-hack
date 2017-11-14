# Installing the Binding

- build the binding
- copy the contents of the custom binding's `bin/Debug/netstandard2.0` folder  into the `bin` folder of the function app
  - if your function app doesn't have a `bin` folder, create one
- run `func extensions sync` to create the `extensions.json` required
  - it should create `extensions.json`, `extensions.deps`, `extensions.dll`, and `extensions.pdb`
  - `extensions.json` would contain
      ``` JSON
      {
        "extensions":[
        ]
       }
      ```
      <i>however</i>, this is what it should look like...
      ``` JSON
      {
          "extensions":[
            { "name": "KeyVaultSecret", "typeName":"KeyVaultSecretsBinding.KeyVaultSecret, KeyVaultSecretsBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"}
          ]
      }
      ```

 - NOTE: If `func extensions sync` fails to generate the `extensions.json` file, this is what it should look like...

    ``` JSON
    {
        "extensions":[
          { "name": "KeyVaultSecret", "typeName":"KeyVaultSecretsBinding.KeyVaultSecret, KeyVaultSecretsBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"}
        ]
    }
    ```

