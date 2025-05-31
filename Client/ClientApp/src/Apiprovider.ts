export abstract class ApiProvider {
    
    static async getAsync<T>(path: string): Promise<T|null> {
        const url = this.getFullUrl(path);
        const response = await fetch(url);
        
        if (!response.ok) {
            throw new Error(`Failed to fetch: ${response.status} | ${response.statusText}`);
        }
        
        return await response.json() as T;
    }
    
    
    static getFullUrl(path: string): string {
        const _apiUrl: string = import.meta.env.VITE_SERVER_BASE_URL;
        
        if (!_apiUrl) {
            console.error('No API URL provided');
            return "";
        }
        
        return new URL(path, _apiUrl).toString();
    }

}