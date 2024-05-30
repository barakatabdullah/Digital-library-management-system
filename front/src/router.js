import {

    createBrowserRouter,

  } from "react-router-dom";
import Layout from "./pages/Layout";
import Home from "./pages/home/index";
import Loan from "./pages/loan";



const router = createBrowserRouter([
    {
      path: "/",
      Component: Layout,
      children: [
        {
          index: true,
        //   loader: homeLoader,
          Component: Home,
        },
        {
            path:"/loan",
            Component: Loan,
          },
     
      ],
    },
  ]);

  export default router
  