
import { Outlet } from 'react-router-dom'
import './App.css'
import NavBar from './components/NavBar'

export default function App() {


  return (
    <>
      <NavBar/>
      <Outlet/>
    </>
  )
}

