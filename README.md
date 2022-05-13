# insomnia-issue-4773

Reproduction helper for https://github.com/Kong/insomnia/issues/4773

## Prerequisites

- Install [.Net Core SDK](https://dotnet.microsoft.com/en-us/download)

## Run and Build

- Run: `dotnet run`

## Problems

We're missing `using System.Net.Http.Headers;` which causes:

```
/Users/filipe.freire@konghq.com/work/issue4773/Program.cs(18,31): error CS0246: The type or namespace name 'MediaTypeHeaderValue' could not be found (are you missing a using directive or an assembly reference?) [/Users/filipe.freire@konghq.com/work/issue4773/issue4773.csproj]

The build failed. Fix the build errors and run again.
```

And then we're adding `{ "Content-Type", "application/json" }` in `Headers`:

```csharp
// (...)
RequestUri = new Uri("http://mockbin.org/request/anything"),
    Headers =
    {
        { "Accept-Language", "en" },
        { "Content-Type", "application/json" }, // THIS IS WRONGFULLY ADDED
    },
// (...)
```

Which causes:

```
Unhandled exception. System.InvalidOperationException: Misused header name, 'Content-Type'. Make sure request headers are used with HttpRequestMessage, response headers with HttpResponseMessage, and content headers with HttpContent objects.
   at System.Net.Http.Headers.HttpHeaders.GetHeaderDescriptor(String name)
   at System.Net.Http.Headers.HttpHeaders.Add(String name, String value)
   at Program.<Main>$(String[] args) in /Users/filipe.freire@konghq.com/work/issue4773/Program.cs:line 5
   at Program.<Main>(String[] args)
```

Related to issue https://github.com/Kong/insomnia/issues/4773
