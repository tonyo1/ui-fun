import { AgGridReact } from "ag-grid-react";
import { useState } from "react";
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-alpine.css";

const Page2 = () => {
  const [rowData] = useState([
    { make: "Toyota", model: "Celica", price: 35000 },
    { make: "Ford", model: "Mondeo", price: 32000 },
    { make: "Porsche", model: "Boxter", price: 72000 },
  ]);

  const [columnDefs] = useState([
    { field: "make", sortable: true },
    { field: "model", sortable: true },
    { field: "price", sortable: true },
  ]);

  return (
    <div className="ag-theme-alpine" style={{ width: "90%", height: "90%;" }}>
      <AgGridReact rowData={rowData} columnDefs={columnDefs}></AgGridReact>
    </div>
  );
};

export default Page2;
