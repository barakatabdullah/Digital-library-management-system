import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export default function NavBar() {
  const navigate = useNavigate();

    return (
      <>
 <nav className="w-screen flex items-center justify-center  py-8 bg-[#111827]">
        <div className="container mx-auto  flex items-center justify-between">

            <div className="flex gap-4">
                <Button outlined  text onClick={()=>navigate('/')}  label='Home' className="text-white"/>
                <Button  text onClick={()=>navigate('loan')}  label='Loan' className="text-white"/>
            </div>

            <div>
                <Button text icon="i-tabler-door-exit" className="text-white"/>
            </div>
        </div>
    </nav>
      </>
    )
  }