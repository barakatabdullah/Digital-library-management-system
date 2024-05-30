import { InputText } from 'primereact/inputText';
import { Password } from 'primereact/password';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import { InputNumber } from 'primereact/inputnumber';
import { getUserToken } from '../../../stores/auth';
import { useForm,Controller } from "react-hook-form"

import api from '../../../config/axios';

function onSubmit(data){
console.log(data)
    // api.post('/Account/Register',{
        
    //         email: payload.email,
    //         password: payload.password,
    //         fullName: payload.fullName
          
    // })

}



export default function Register() {
    const {  control, handleSubmit } = useForm()
return(
    <div className="w-screen h-screen flex items-center justify-center">
    <Card className="w-2/8">
        
            <h3 className="text-center mb-8 font-bold text-8">Register</h3>
            <form className="flex flex-col gap-8 w-full">
                <div className="flex flex-col gap-2">
                    <label className="font-bold" htmlFor="username">Username</label>
                    <Controller
                    control={control}
                    rules={{
                      required: true,
                    }}
                    render={({ field: { value } }) => (
                    <InputText value={value} id="fullname"  />
                    )}
                    name="fullName"
                    />
                </div>
                <div className="flex flex-col gap-2 ">
                    <label className="font-bold" htmlFor="email">Email</label>
                    <Controller
                    control={control}
                    rules={{
                      required: true,
                    }}
                    render={({ field: { value } }) => (
                    <InputText value={value} id="email"  />
                )}
                name="email"
                />
                </div>
                <div className="flex flex-col gap-2 ">
                    <label className="font-bold" >Password</label>
                    <Controller
                    control={control}
                    rules={{
                      required: true,
                    }}
                    render={({ field: { value } }) => (
                    <Password value={value} pt={{
                        input: { className: 'w-full' }
                    }}  inputId="password" />
                     )}
                    name="password"
                    />
                </div>
                {/* <div className="flex flex-col gap-2 ">
                    <label className="font-bold" htmlFor="passwordConfirmation">Password Confirmation</label>
                    <Password pt={{
                        input: { root: { className: 'w-full' } }
                    }} v-model="passwordConfirmation" inputId="passwordConfirmation" />
                </div> */}
                <Button label="Register" onClick={() => handleSubmit(onSubmit)} />
            </form>

       
    </Card>

</div>
)

}
