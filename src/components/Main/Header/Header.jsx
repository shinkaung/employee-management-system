import React, { useContext } from 'react';

/** CSS Imports ***/
import './Header.css';

/*** Router Imports  ***/
import { useNavigate } from 'react-router-dom';

/*** Component Imports ***/
import Dropdown from 'components/Common/Dropdown/Dropdown';

/*** Icon Imports ***/
import { FaBars } from "react-icons/fa6";
import { MdApps } from 'react-icons/md';
import { IoNotifications } from "react-icons/io5";

/*** Context Imports ***/
import SidebarContext from 'contexts/SidebarContext';

function Header() {

    /* useContext */
    const { isSidebarOpen, setIsSidebarOpen } = useContext(SidebarContext);

    /* Router */
    const navigate = useNavigate();

    /* Functions */
    const handleLogout = () => {
        console.log('Logout');
    }

    return (
        <div className='header'>
            <div className='header_left' style={{flex: '1', fontFamily: 'Playfair Display', fontWeight: 'bold', fontStyle: 'italic', fontSize: '25px'}}>

                {/* Menu Bar */}
                <span className='header_icon'
                    onClick={() => setIsSidebarOpen(!isSidebarOpen)}>
                    <FaBars size={20} />
                </span>

                {/* Logo */}
                <span style={{color: 'red'}}>E</span>
                <span style={{color: 'green'}}>M</span>
                <span style={{color: 'blue'}}>S</span>
            </div>

            <div className='header_right'>
                <span className='header_icon'>
                    <IoNotifications id='icon' size={26} />
                    <span id='badge'>0</span>
                </span>
                <span className='header_icon'>
                    <MdApps size={26} />
                </span>
                {
                    <Dropdown>
                        <Dropdown.Title enableArrow={false}>
                            <span>Shan</span>
                            <img className='header_right_avatar'
                                src='https://cdn4.iconfinder.com/data/icons/avatars-xmas-giveaway/128/batman_hero_avatar_comics-512.png'
                                alt='avatar' />
                        </Dropdown.Title>
                        <Dropdown.Menu>
                            <Dropdown.Item clickable={false}>
                                <div className='d-flex flex-column'>
                                    <span>Shin Kaung</span>
                                    <span>a@gmail.com</span>
                                </div>
                            </Dropdown.Item>
                            <Dropdown.Separator />
                            <Dropdown.Item
                                onClick={() => navigate('/user/account/profile')}>
                                My Profile
                            </Dropdown.Item>
                            <Dropdown.Item>Order History</Dropdown.Item>
                            <Dropdown.Item
                                style={{ 'color': 'red' }}
                                onClick={() => handleLogout()}>
                                Logout
                            </Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                }
            </div>
        </div >
    );
}

export default Header;