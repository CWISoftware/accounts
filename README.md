[![Build status](https://ci.appveyor.com/api/projects/status/34m8w6uq27u0a9ey?svg=true)](https://ci.appveyor.com/project/contascwi/accounts)
[![Coverage Status](https://coveralls.io/repos/CWISoftware/accounts/badge.svg?branch=master&service=github)](https://coveralls.io/github/CWISoftware/accounts?branch=master)
[![Stories in Ready](https://badge.waffle.io/CWISoftware/accounts.png?label=ready&title=Ready)](https://waffle.io/CWISoftware/accounts)

# accounts
WIP: CWI OAuth2 provider

http://www.asp.net/identity/overview/getting-started/aspnet-identity-recommended-resources

### Dependencies

* Install [npm](https://www.npmjs.com/package/npm)
* Install [Bower](http://bower.io/#install-bower)

### Install the DNX environment

Install the [ASP.NET 5](https://github.com/aspnet/Home#cmd)

Open new shell and execute command about to install runtime:

	dnvm update

### Running first time

Refresh packages from nuget:

	dnu restore

### Run web application

Windows:

	dnx -p .\src\Accounts.Web\ web

Mac\Linux:

	dnx -p .\src\Accounts.Web\ kestrel

### Run tests

    dnx -p .\test\Accounts.Web.Tests\ test

## Notes:

1. dnxcore50 is not used because `System.DirectoryServices.AccountManagement` namespace is not suported in dnxcore50. That will be possible when we refactor this feature or use another strategy.