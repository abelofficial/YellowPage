import React from "react";
import { Person } from "../types";

export interface PersonItemProps {
  item: Person;
}

const PersonItem = ({ item }: PersonItemProps) => {
  return (
    <div>
      <h3>{item.id}</h3>
      <h3>
        {item.firstName} {item.lastName}
      </h3>
    </div>
  );
};

export default PersonItem;
