# Capstone project 

## Project information

-   Project name: [ Digital-library-management-system / Backend]
-   Project description:“a projact developed for Mosnad challanges”
## Technologies

    - ASP.Net core v8


## Organization:
   -   Mosnad

### Installation

1. Clone the repository:
```shell
git clone https://github.com/Academic-Abdo/TravelSystem.git](https://github.com/snacomds/Digital-library-management-system
```

2. Navigate to the project directory:
```shell
cd TravelSystem
```

3. Restore dependencies using Dotnet commend:
```shell
dotnet restore
```

## Development process

-   When commiting you will have to use `git cz` and then go through the process. Look at the first commit I made to know what that means.


## 🔨 Build

To build this project

Apply data base migration

```bash
 dotnet ef database-update
```

Build and run the project using Dotnet:

```bash
 dotnet run
```


## 🚀 Deployment

To deploy this project run

```bash
dotnet publish
```



## 🌵 Branches

We use an agile continuous integration methodology, so the version is frequently updated and development is really fast.

1. develop is the development branch.

2. master is the production branch.

3. No other permanent branches should be created in the main repository, you can create feature branches but they should get merged with the master.

**Steps to work with feature branch**

1. To start working on a new feature, create a new branch prefixed with feature and followed by feature name. (ie. feature/featurename-issuenumber)
2. Once you are done with your changes, you can raise PR.

**Steps to create a pull request**

1. Make a PR to develop branch.
2. It must pass all continuous integration checks and get positive reviews.
3. After this, changes will be merged to develop branch.
