import React from "react";
import { Business } from "../types";

export interface BusinessItemProps {
  item: Business;
}

const BusinessItem = ({ item }: BusinessItemProps) => {
  return (
    <div>
      <h3>{item.id}</h3>
      <h3>{item.name}</h3>
      <h3>{item.description}</h3>
    </div>
  );
};

export default BusinessItem;
