import React, { SyntheticEvent, useState } from 'react';
import { useNavigate } from 'react-router-dom';


const AddProduct = () => {
    const navigate = useNavigate();
    const [userName, setUserName] = useState('');
    const [complaintDescription, setComplaintDescription] = useState('');

    const handleSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const response = await fetch('/tickets', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({userName: userName, complaintDescription: complaintDescription})
        });
        if (response.ok) {
            navigate('/');
        }
    };

    return (
        <main className="d-flex justify-content-center text-center">
            <form onSubmit={handleSubmit}>
                <h1 className="h3 mb-3 fw-normal">Add Ticket</h1>

                <div className="form-group">
                    <label htmlFor="userName">User</label>
                    <input type="text" className="form-control" id="userName" placeholder="User name" required value={userName} onChange={e => setUserName(e.target.value)} />
                </div>
                <div className="form-group">
                    <label htmlFor="complaintDescription">User</label>
                    <input type="text" className="form-control" id="complaintDescription" placeholder="Complaint" required value={complaintDescription} onChange={e => setComplaintDescription(e.target.value)} />
                </div>
                <button className="btn btn-primary py-2" style={{ marginTop: '10px' }} type="submit">Submit</button>
            </form>
        </main>
    );
};

export default AddProduct;
