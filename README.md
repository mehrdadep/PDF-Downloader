# PDF-Downloader
crawling websites to get and download pdf files

# Crawling methodolgy
1. using HttpWebRequest to get data from websites
2. find links with .pdf extension and application/pdf content-type
3. save crawled link in local sqlite database
4. crawl and download pdf file in desired folder with site name subfolder
5. find and save rss links

# Multithreading
1. using SemaphoreSlim to manage threads of requests and saving files
2. non-blocking UI threads

# Batch input
1. add .txt files with a site url per line
2. add excel .xlsx file with a column named "site"
3. this site urls save into local database after proccessing and can be used later



