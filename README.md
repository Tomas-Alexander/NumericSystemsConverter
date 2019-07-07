# NS Converter
This is a library that allow convert numbers in different numeral systems.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

For the use of this program is necessary to have installed the **.NET Core 2.2 Runtime** version, if it is not installed, go to this [page](https://dotnet.microsoft.com/download).

* Click on "Download .Net Core Runtime"
* Wait until the download has finish
* Open the installer
* Check "I agree to the licence terms and conditions"
* Click on "Install"
* Finally wait untile the installation has finish

### Installing

First is necessary download this project or clone it using git.
```
git clone https://github.com/jordymateo/NumericSystemsConverter.git
```

If you don't have git installed go to this [page ](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) for installation step by step.

### How to use
Open the command line, and go to the proyect folder where you downloaded it.

```
cd <your-project-path>/NSConverterConsole
```

And run it using

```
dotnet run
```

When the program starts, it will ask for the file path that will be used to obtain the necessary data.

File format (data.txt): 
```
value | value-numerical-system | result-numerical-system
```

Then it will request a path *"path + filename.txt"* that will create a new file with the data processed.

File format (result.txt): 
```
value | value-numerical-system | result-numerical-system | result
```

The convertion of numerical systems used is:
<small>
Value|Numerical System
--- | ---
2|Binary
8|Octal
10|Decimal
16|Hexadecimal
</small>

### Example

1. Create a dataExample.txt:
```
10 | 10 | 16
a4 | 16 | 2
```

2. Run the program
3. The program request the data file:
```
File path (read data): <path>/dataExample.txt
```

4. The program request the file of data result:
```
File path (write data result): <path>/resultExample.txt
```

5. The program will process the data.
6. The result will be:
```
10 | 10 | 16 | a
a4 | 16 | 2 | 10100100
```

## Contributing

Please read [CONTRIBUTING.md](https://github.com/jordymateo/NumericSystemsConverter/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.


## Authors

* **Jordy Mateo** - *Initial work*

See also the list of [contributors](https://github.com/jordymateo/NumericSystemsConverter/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/jordymateo/NumericSystemsConverter/blob/master/LICENSE) file for details

