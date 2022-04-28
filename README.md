Output with DotNetFramework4.8

```
OK!
```

Output with DotNet6

```
System.InvalidOperationException
Handle is not initialized.
   at System.Runtime.InteropServices.GCHandle.FromIntPtr(IntPtr value)
   at uno.util.to_cli<class com::sun::star::uno::XComponentContext>(Reference<com::sun::star::uno::XComponentContext>* x)
   at uno.util.Bootstrap.defaultBootstrap_InitialComponentContext(String ini_file, IDictionaryEnumerator bootstrap_parameters)
   at uno.util.Bootstrap.defaultBootstrap_InitialComponentContext()
   at ConsoleDotNetFramework.Program.Main() in Program.cs:line 26
```
