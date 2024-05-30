import { create } from 'zustand'

export const useAuthStore= create((set,get) => ({
    name: localStorage.getItem('user'),
    token: localStorage.getItem('token'),

    actions:{

        getUserToken:()=>get().token,
        setUserName(name){
            set({name})
        },
        setUserToken(token){
            set({token})
        },
    }


  }))

  export const { setUserName,setUserToken,getUserToken } = useAuthStore.getState().actions