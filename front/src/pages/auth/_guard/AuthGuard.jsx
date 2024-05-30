import { getUserToken } from "@/stores/auth";
import { Navigate } from "react-router-dom";

export default function AuthGuard({children}) {
    const isAuthenticated= (getUserToken() !== null && getUserToken()!=='') ? true : false
    
  
    if (!isAuthenticated) {
      // Redirect them to the /login page, but save the current location they were
      // trying to go to when they were redirected. This allows us to send them
      // along to that page after they login, which is a nicer user experience
      // than dropping them off on the home page.
      return <Navigate to="/auth/login" replace  />;
    }
  
    return children;
  }