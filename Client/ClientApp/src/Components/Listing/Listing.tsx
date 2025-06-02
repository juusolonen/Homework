import "./Listing.css"
import {type ReactNode, useMemo} from "react";
import {Utility} from "../../Utility.ts";

export type Listable = {
    id: number;
}

type ListingProps<T extends Listable> = {
    items: T[];
    filterText?: string | null; 
    filterKey?: keyof T;
    renderItem: (item: T) => ReactNode;
}
const Listing = <TItem extends Listable>({items, filterText, filterKey, renderItem}: ListingProps<TItem>) => {
    
    const filteredItems: TItem[] = useMemo(
        () => Utility.filter<TItem>(items, filterText, filterKey),
        [filterText, items, filterKey]
    );
    
    const getKey = (item: Listable) => {
        return `listingItem_${item.id}_${Date.now()}`;
    }
    
    return (
        <div className="listing row row-cols-sm-1 row-cols-md-4 row-cols-lg-4 row-cols-xl-6 g-4 mt-3 min-vh-100">
            { filteredItems.length > 0 &&
               filteredItems.map((item: TItem) => (
                   <div className="col shadow-sm px-1 mt-3 rounded listing-column"
                        key={getKey(item)}
                   >
                       {renderItem(item)}
                   </div>
               ))
            }
        </div>
    )
}

export default Listing;
