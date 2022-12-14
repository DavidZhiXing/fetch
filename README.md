## Fetch
This is a command line tool for fetching pages from the web. 
All the services are Dependency Injected, so you can easily extend the functionality.

![ ](images/fetch.png)

## Usage
``` bash
$ ./fetch [Options] <Urls...>
```
Options:
``` bash
  -m, --metadata    Prints out the metadata for the webpage(s) being fetched.

  -o, --output      (Default: ) Output folder to download the webpage files.

  --help            Display this help screen.

  --version         Display version information.
```

- Fetch pages from the web
```bash
$ ./fetch https://www.google.com https://www.facebook.com
```
- Fetch pages from the web and print the metadata
```bash
$ ./fetch --metadata https://www.google.com https://www.facebook.com
```
## Build and Run
- Docker
``` bash
docker build -t fetch .
docker run --rm -it fetch [Options] <Urls...>
```
- vs studio 2022
``` batch
dotnet build
dotnet run --project fetch [Options] <Urls...>
```


## Todo
- [ ] <del>Add output options to save the fetched pages to a file.</del>
- [ ] <del>Download the pages in parallel.</del>
- [ ] Download all the pages assets (images, css, js, etc).
- [ ] Beautify the console output.
- [ ] Seperate the services and the interfaces each in a different project.
- [ ] Add unit tests.
- [ ] Add github actions to build and test the solution.

