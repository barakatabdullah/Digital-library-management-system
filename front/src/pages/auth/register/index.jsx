import { InputText } from "primereact/inputText";
import { Password } from "primereact/password";
import { Button } from "primereact/button";
import { Card } from "primereact/card";

import { useForm, Controller } from "react-hook-form";



import { onSubmit } from "./_utils";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const methods = useForm();
  const navigate = useNavigate()
  
  return (
    <div className="w-screen h-screen flex items-center justify-center">
      <Card className="w-2/8">
        <h3 className="text-center mb-8 font-bold text-8">Register</h3>
        <form
          onSubmit={methods.handleSubmit(onSubmit)}
          className="flex flex-col gap-8 w-full"
        >
          <div className="flex flex-col gap-2">
            <label className="font-bold" htmlFor="username">
              Username
            </label>
            <Controller
              control={methods.control}
              rules={{
                required: true,
              }}
              render={({ field }) => <InputText {...field} id="fullname" />}
              name="fullName"
            />
          </div>
          <div className="flex flex-col gap-2 ">
            <label className="font-bold" htmlFor="email">
              Email
            </label>
            <Controller
              control={methods.control}
              rules={{
                required: true,
              }}
              render={({ field }) => <InputText {...field} id="email" />}
              name="email"
            />
          </div>
          <div className="flex flex-col gap-2 ">
            <label className="font-bold">Password</label>
            <Controller
              control={methods.control}
              rules={{
                required: true,
              }}
              render={({ field }) => (
                <Password
                  {...field}
                  pt={{
                    input: { className: "w-full" },
                  }}
                  inputId="password"
                />
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
          <Button label="Register" type="submit" />
        </form>
        <div className="flex justify-center w-full">
            <Button
            label="or Login with your account"
            link
            onClick={()=>navigate('/auth/login')}

            />
        </div>
      </Card>
    </div>
  );
}
