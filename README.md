This example is using SingleStore cluster in a Docker container.

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

Adjust the connection details in appsettings.Development.json, run dotnet restore, and then run the app.
