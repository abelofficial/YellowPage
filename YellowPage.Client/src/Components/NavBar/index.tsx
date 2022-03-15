import React from "react";
import { Link } from "react-router-dom";

const NavBar = () => {
  return (
    <header className='app__toolbar'>
      <div className='toolbar__logoContainer'>
        <img src='/logo.png' alt='' className='image__logo' />
        <h4>Yellow Page</h4>
      </div>
      <div className='toolbar__linksContainer'>
        <Link to='/' className='toolbar__link'>
          <p>Home</p>
        </Link>

        <Link to='/Add' className='toolbar__link'>
          <p>Add</p>
        </Link>
      </div>
    </header>
  );
};

export default NavBar;
