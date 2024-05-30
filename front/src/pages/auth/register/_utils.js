import api from "@/config/axios";
import { setUserName, setUserToken } from "../../../stores/auth";
import router from "@/router";




export const onSubmit = async (data) => {

    await api.post("/Account/Register",{
        
            email: data.email,
            password: data.password,
            fullName: data.fullName
          
    }).then(res=>{
        if(res.status ===201){
            localStorage.setItem('name', res.data?.fullName)
    localStorage.setItem('token', res.data?.jwToken)
            setUserName(res.data?.fullName)
            setUserToken(res.data?.jwToken)
            router.navigate('/')
        }
    });

    
  };