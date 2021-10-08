This example is using **SingleStore** cluster in a Docker container and **EntityFramework ORM**.

**Configuration:**

Sign up for a free SingleStore license.

Get the password and key provided when using the steps for building a docker image with a cluster for your account

Execute the following PowerShell script to build and run the docker container

**docker run -i --init `
    --name memsql-ciab `
    -e LICENSE_KEY="YOUR_LICENSE_KEY_HERE" `
    -e ROOT_PASSWORD="YOUR_ROOT_PASSWORD_HERE" `
    -p 3306:3306 -p 8080:8080 `
    memsql/cluster-in-a-box
docker start memsql-ciab**

Configure your EntityFramework database context using the adjusted connection string in your appsettings.Development.json file. SingleStore is usign EF MySQL provider.

Run dotnet restore, and then run the app.
