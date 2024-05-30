import {

    createBrowserRouter,

  } from "react-router-dom";
import Layout from "./pages/Layout";
import Home from "./pages/home/index";
import Loan from "./pages/loan";
import Register from "./pages/auth/register";
import login from "./pages/auth/login";



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
    {
        path: "/auth",
        children: [
            {
                path:"register",
                Component: Register,
              },
              {
                path:"login",
                Component: login,
              },
        ]
    }
  ]);

  export default router
  