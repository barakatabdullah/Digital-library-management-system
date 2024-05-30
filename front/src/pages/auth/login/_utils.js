import api from "@/config/axios";
import { setUserName, setUserToken } from "@/stores/auth";
import router from "@/router";




export const onSubmit = async (data) => {

    await api.post("/Account/login",{
        
            email: data.email,
            password: data.password,
          
    }).then(res=>{
        console.log(res)
        if(res.status ===200){
            localStorage.setItem('name', res.data?.fullName)
            localStorage.setItem('token', res.data?.jwToken)
            setUserName(res.data?.fullName)
            setUserToken(res.data?.jwToken)
            router.navigate('/')
        }
    });

    
  };