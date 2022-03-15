import React from "react";
import { NavLink } from "react-router-dom";

const NavBar = () => {
  return (
    <header className='app__toolbar'>
      <div className='toolbar__logoContainer'>
        <img src='/logo.png' alt='' className='image__logo' />
        <h4>Yellow Page</h4>
      </div>
      <div className='toolbar__NavLinksContainer'>
        <NavLink to='/' className='toolbar__NavLink'>
          <p>Home</p>
        </NavLink>

        <NavLink to='/Add' className='toolbar__NavLink'>
          <p>Add</p>
        </NavLink>
      </div>
    </header>
  );
};

export default NavBar;
