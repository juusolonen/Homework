export abstract class Utility {
    public static truncate(str: string, limit: number): string {
        return str.length > limit 
            ? str.substring(0, limit) + "..." 
            : str;
    }
    
    public static filter<T>(items: T[], filterText?: string | null, key?: keyof T): T[] {
        if (!key || !filterText?.length || filterText?.length < 1) {
            return items;
        }
        
        return  items.filter(item => {
            const value = item[key];

            if (typeof value === "string") {
                return value.toLowerCase().includes(filterText.toLowerCase());
            }
            
            return false;
        });
    }
}