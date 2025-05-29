// This script configures the .NET Core React development server to work with the ASP.NET Core SPA proxy
import * as process from 'process';
import { fileURLToPath } from 'url';
import path from 'path';

// Get the current directory
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// Set environment variables for React development server
// Allow browser to open automatically
process.env.ASPNETCORE_URLS = process.env.ASPNETCORE_URLS || 'https://localhost:5001;http://localhost:5000';

// Set the port for the React development server to match SpaProxyServerUrl in the .csproj file
process.env.PORT = process.env.PORT || '5002';

console.log('React development server configuration complete.');
console.log(`Server will listen on port ${process.env.PORT}`);

