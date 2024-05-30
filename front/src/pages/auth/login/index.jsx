import { InputText } from "primereact/inputText";
import { Password } from "primereact/password";
import { Button } from "primereact/button";
import { Card } from "primereact/card";

import { useForm, Controller } from "react-hook-form";



import { onSubmit } from "./_utils";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const methods = useForm();
  const navigate=useNavigate()
  
  return (
    <div className="w-screen h-screen flex gap-4 items-center justify-center">
      <Card className="w-2/8">
        <h3 className="text-center mb-8 font-bold text-8">Login</h3>
        <form
          onSubmit={methods.handleSubmit(onSubmit)}
          className="flex flex-col gap-8 w-full"
        >
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

          <Button label="Login" type="submit" />
        </form>
        <div className="flex justify-center w-full">
            <Button
            label="Register new account"
            link
            onClick={()=>navigate('/auth/register')}

            />
        </div>
      </Card>
    </div>
  );
}
