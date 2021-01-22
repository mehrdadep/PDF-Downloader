# PDF Downloader

Crawl websites and download all the pdf files from them

## Requirements

- `.NET` sdk version 4.5+
- `mono-dev` (For linux)

## Dependencies

- `CSharp.SqlServerCe` version 1.0.2.6
- `HTMLAgilityPack` version 1.7.0

## Crawling methodology

- Use `HttpWebRequest` to get data from websites
- Find links with `.pdf` extension and `application/pdf` content-type
- Save crawled link in local `sqlite` database
- Crawl and download pdf file in desired folder with site name subfolder
- Find and save rss links

## Multithreading

- Use `SemaphoreSlim` to manage threads of requests and saving files
- Use non-blocking UI threads

## Batch input

### Option 1: `.txt` file

- Use a `.txt` file that contains a site urls per line

### Option 2: `xlsx` file

- Use a `.xlsx` file that contains site urls under a column named "site"

## Running

Use `bin/Release/PDF Downloader.exe` to run the program
