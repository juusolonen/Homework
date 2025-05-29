// This script sets up HTTPS for the application using the ASP.NET Core HTTPS certificate
import fs from 'fs';
import path from 'path';
import { fileURLToPath } from 'url';
import * as process from 'process';

// Get the current directory
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const baseFolder = process.env.HOME || (process.env.USERPROFILE || path.resolve(path.dirname(__dirname), '../'));
const certFolder = path.join(baseFolder, '.aspnet', 'https');

// Certificate file names expected by ASP.NET Core
const keyFilePath = path.join(certFolder, 'devcert.key');
const certFilePath = path.join(certFolder, 'devcert.pem');

if (!fs.existsSync(keyFilePath) || !fs.existsSync(certFilePath)) {
  console.error('Certificate files not found. HTTPS will not be configured correctly.');
  console.error('Run "dotnet dev-certs https --export-path devcert.pem --format PEM" to generate the certificate.');
  console.error(`Then copy both certificate files to ${certFolder}`);
  process.exit(1);
}

// Set certificate-related environment variables for Vite
process.env.SSL_CRT_FILE = certFilePath;
process.env.SSL_KEY_FILE = keyFilePath;

console.log('HTTPS certificate configuration complete.');

