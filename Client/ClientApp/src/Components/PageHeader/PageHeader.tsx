import React from "react";
interface PageHeaderProps {
    title: string;
}
const PageHeader: React.FunctionComponent<PageHeaderProps> = ({title}) => {
    return (
            <div className="row">
                <div className={"page-header mb-4 pb-4"}>
                    <h1>{title}</h1>
                </div>
            </div>
    )
}

export default PageHeader;
