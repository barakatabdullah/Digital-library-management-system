import React from "react";
import ReactDOM from "react-dom/client";
import { PrimeReactProvider } from "primereact/api";
import { RouterProvider } from "react-router-dom";
import "virtual:uno.css";
import "./styles/index.css";
import router from "./router";


export function Fallback() {
  return <p>Performing initial data load</p>;
}

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <PrimeReactProvider>
      <RouterProvider router={router}  />
    </PrimeReactProvider>
  </React.StrictMode>
);
