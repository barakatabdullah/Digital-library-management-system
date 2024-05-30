
import { Outlet } from 'react-router-dom'
import './styles/index.css'
import NavBar from './components/NavBar'

export default function App() {


  return (
    <>
      <NavBar/>
      <Outlet/>
    </>
  )
}

