# 6 letter words
The goal of this repo was to create an application that could evaluate a file containing `1` through `N` letter words and find all possible combinations of those words that would create a `N` letter word which can be found in the file.

E.g.:  
<code>foobar</code>
<code>fo</code>
<code>obar</code>

The result is outputted to an file in the format: <code>fo+obar=foobar</code>

## Usage
In the root of the project there is an appsettings.json file.

```json
{
  "AppConfig": {
    "InputPath": "",
    "OutputPath": "",
    "WordLength": 6
  }
}
```

<code>InputPath</code>: This is the absolute path to the input file.

<code>OutputPath</code>: This is the absolute path to the output file.

<code>WordLength</code>: This is the length of the 'complete' words in the input file.

Update the <code>appsettings.json</code> and ensure <code>InputPath</code> and <code>OutputPath</code> direct to the appropriate file.
