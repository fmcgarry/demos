'use client'

import { useState } from "react";

export default function Square() {
    const [value, setValue] = useState('');

    function handleClick() {
        setValue('X');
    }

    return (
        <>
            <button className="square bg-indigo-500 w-6 h-6 border border-black" onClick={handleClick}>{value}</button>
        </>
    );
}
