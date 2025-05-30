export abstract class Utility {
    public static truncate(str: string, limit: number): string {
        return str.length > limit 
            ? str.substring(0, limit) + "..." 
            : str;
    }
}