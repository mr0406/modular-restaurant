# Azurite

Azure Storage emulator for local development. You need to run this before running app locally.

## Instalation

1. Install Node.js
2. npm install -g azurite
3. Create folder: C:\Azurite
4. azurite --silent --location c:\azurite --debug c:\azurite\debug.log

## Run
azurite --silent --location c:\azurite --debug c:\azurite\debug.log

## File url

http://127.0.0.1:10000/devstoreaccount1/[container-name]/[file-name-with-extension]

Example:
http://127.0.0.1:10000/devstoreaccount1/menuitemimages/5f693561-875a-4b10-8695-64001a12d864.jpg

## Remarks

On disk folder files are stored as binary data. The structure of files is not related to their logical representation (containers, blobs).

To see folder and files logical structure (with correct names) you need to install: Microsoft Azure Storage Explorer
