
import React from 'react';
import { useNavigate } from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import styleHome from "../style_sheets/Home.module.css";
import coverImg from "../Assets/Beach.jpg";
import paymentImg from "../Assets/ezpayment.png";
import nearbyImg from "../Assets/Nearby.png";
import covidImg from "../Assets/Safe.png";
import priceImg from "../Assets/Prices.png";

const Home = () => {
    const navigate = useNavigate(); // Initialize useNavigate hook

    const handleExploreClick = () => {
        navigate('/explore'); // Navigate to Explore page
    };

    return (
        <>
        <div className={styleHome.container}>
            <img src={coverImg} alt="Cover Beach" className={styleHome.img} />
            <div className={styleHome.layer}>
                <div className={styleHome.centered}>
                    <div className={styleHome.headerTxt}>TRAVEL TO EXPLORE</div>
                    <div className={styleHome.sloganTxt}>Stop worrying about the potholes in the road and enjoy the journey <br/>~ Babs Hoffman ~</div>
                    <button className={styleHome.exploreBtn} onClick={handleExploreClick}>Explore Now</button>
                </div>
            </div>
        </div>
        <div className={`row row-cols-md-4 g-5`} style={{margin: "40px 70px 0px 70px"}}>
            <div className={`col`}>
                <div className={`card h-100 ${styleHome.cardContainer}`}>
                    <div className={styleHome.imgBg}>
                        <img src={priceImg} className={`card-img-top ${styleHome.cardImg}`} alt="..."/>
                    </div>
                    <div className={`card-body`} style={{marginLeft: "10px", marginRight: "15px"}}>
                        <h5 className={`card-title ${styleHome.cardHeader}`}>Get Best Prices</h5>
                        <p className={`card-text ${styleHome.cardDes}`}>Pay through our application and save thousands and get amazing rewards</p>
                    </div>
                </div>
            </div>
            <div className={`col`}>
                <div className={`card h-100 ${styleHome.cardContainer}`}>
                    <div className={styleHome.imgBg}>
                        <img src={covidImg} className={`card-img-top ${styleHome.cardImg}`} style={{width: "45px"}} alt="..."/>
                    </div>
                    <div className={`card-body`} style={{marginLeft: "10px", marginRight: "20px"}}>
                        <h5 className={`card-title ${styleHome.cardHeader}`}>Travel Safe</h5>
                        <p className={`card-text ${styleHome.cardDes}`}>We have all the curated hotels that have all the precaution for a travel safe environment</p>
                    </div>
                </div>
            </div>
            <div className={`col`}>
                <div className={`card h-100 ${styleHome.cardContainer}`}>
                    <div className={styleHome.imgBg}>
                        <img src={paymentImg} className={`card-img-top ${styleHome.cardImg}`} style={{width: "45px", marginTop: "5px"}} alt="..."/>
                    </div>
                    <div className={`card-body`} style={{marginLeft: "10px", marginRight: "20px"}}>
                        <h5 className={`card-title ${styleHome.cardHeader}`}>Flexible Payment</h5>
                        <p className={`card-text ${styleHome.cardDes}`}>Enjoy the flexible payment through our app and get rewards on every payment</p>
                    </div>
                </div>
            </div>
            <div className={`col`}>
                <div className={`card h-100 ${styleHome.cardContainer}`}>
                    <div className={styleHome.imgBg}>
                        <img src={nearbyImg} className={`card-img-top ${styleHome.cardImg}`} style={{width: "45px"}} alt="..."/>
                    </div>
                    <div className={`card-body`} style={{marginLeft: "10px", marginRight: "20px"}}>
                        <h5 className={`card-title ${styleHome.cardHeader}`}>Find The Best Near You</h5>
                        <p className={`card-text ${styleHome.cardDes}`}>Find the best  places to visit near you in a single click</p>
                    </div>
                </div>
            </div>
        </div>
        <section className={styleHome.reviewSection}>
            <div className="row d-flex justify-content-center">
                <div className="col-md-10 col-xl-8 text-center">
                <h3 className="mb-4" style={{fontWeight: "700", fontSize: "32px"}}>Here's What Our Customers Say?</h3>
                <p className="mb-4 pb-2 mb-md-5 pb-md-0">
                Discover the magic of effortless travel planning with us. Our customers rave about our personalized itineraries, unbeatable deals, and exceptional customer support. Let their experiences inspire your next adventure!
                </p>
                </div>
            </div>

            <div className="row text-center">
                <div className={`col-md-4 mb-5 mb-md-0`} style={{padding: "10px"}}>
                    <div className={styleHome.reviewCard}>
                        <div className="d-flex justify-content-center mb-4">
                            <img src="https://cdn4.sharechat.com/img_11762_2f7e7367_1678802009109_sc.jpg?tenant=sc&referrer=pwa-sharechat-service&f=109_sc.jpg" alt=".."
                            className="rounded-circle shadow-1-strong" style={{width: "150px", height: "150px"}} />
                        </div>
                        <h5 className="mb-3">Arjun</h5>
                        <h6 className="text-primary mb-3">Travel Vlogger</h6>
                        <p className="px-xl-3">
                            <i className="fas fa-quote-left pe-2"></i>"My trip was absolutely amazing! Your website made planning a breeze. I can't wait to book my next adventure through you."
                        </p>
                    </div>
                </div>
                <div className={`col-md-4 mb-5 mb-md-0`} style={{padding: "10px"}}>
                    <div className={styleHome.reviewCard}>
                        <div className="d-flex justify-content-center mb-4">
                            <img src="https://i.pinimg.com/originals/2b/41/f6/2b41f6da7c57958fb1941d78f71b2a29.jpg" alt=".."
                            className="rounded-circle shadow-1-strong" style={{width: "150px", height: "150px"}}  />
                        </div>
                        <h5 className="mb-3">Sneha</h5>
                        <h6 className="text-primary mb-3">Traveller</h6>
                        <p className="px-xl-3">
                            <i className="fas fa-quote-left pe-2"></i>"The tour exceeded my expectations! The guides were knowledgeable and friendly. I'll definitely recommend your company to my friends."
                        </p>
                    </div>
                </div>
                <div className={`col-md-4 mb-0`} style={{padding: "10px"}}>
                    <div className={styleHome.reviewCard}>
                        <div className="d-flex justify-content-center mb-4">
                            <img src="https://i.pinimg.com/1200x/64/8c/f9/648cf92c0b82b7c20bf9e9d815f61aff.jpg" alt=".."
                            className="rounded-circle shadow-1-strong" style={{width: "150px", height: "150px"}}  />
                        </div>
                        <h5 className="mb-3">Rohit</h5>
                        <h6 className="text-primary mb-3">Traveller</h6>
                        <p className="px-xl-3">
                            <i className="fas fa-quote-left pe-2"></i>"I had the best time on this tour. Your attention to detail was impressive. Thank you for creating such a memorable experience."
                        </p>
                    </div>
                </div>
            </div>
        </section>
        <div style={{padding: "100px 100px 20px 100px"}}>
            <p className={`text-center ${styleHome.destinationHeading}`}><span style={{color:"#4468E2"}}>BEST</span> DESTINATIONS</p>
            <div className="row">
                <div className="col-lg-4 col-md-12 mb-4 mb-lg-0">
                    <img
                        src="https://images.unsplash.com/photo-1663089551730-0fc5bedde759?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjJ8fG1haGFyYXNodHJhJTIwbGFuZHNjYXBlfGVufDB8fDB8fHww"
                        className="w-100 shadow-1-strong rounded mb-4"
                        alt="Boat on Calm Water"
                    />

                    <img
                        src="https://images.unsplash.com/photo-1606843046080-45bf7a23c39f?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fG1haGFyYXNodHJpYW4lMjBmb29kfGVufDB8fDB8fHww"
                        className="w-100 shadow-1-strong rounded mb-4"
                        alt="Wintry Mountain Landscape"
                    />
                </div>

                <div className="col-lg-4 mb-4 mb-lg-0">
                    <img
                        src="https://media.istockphoto.com/id/1334093184/photo/ganapati.jpg?s=612x612&w=0&k=20&c=QBzi3lle4o21yZiaptY2ZN-ia-QVG2JYiKe3o0lL9IM="
                        className="w-100 shadow-1-strong rounded mb-4"
                        alt="Mountains in the Clouds"
                    />

                    <img
                        src="https://media.istockphoto.com/id/629821246/photo/kailas-temple-in-ellora-caves-complex-in-india.jpg?s=612x612&w=0&k=20&c=ei3N4dugQCPoifA-fE5aDIcgkGqkQgQ2_ASvdxxVnV0="
                        className="w-100 shadow-1-strong rounded mb-4"
                        alt="Boat on Calm Water"
                    />
                </div>

                <div className="col-lg-4 mb-4 mb-lg-0">
                    <img
                        src="https://media.istockphoto.com/id/539018660/photo/taj-mahal-hotel-and-gateway-of-india.jpg?s=612x612&w=0&k=20&c=L1LJVrYMS8kj2rJKlQMcUR88vYoAZeWbYIGkcTo6QV0="
                        className="w-100 shadow-1-strong rounded mb-4"
                        alt="Waves at Sea"
                    />

                    <img
                        src="https://images.unsplash.com/photo-1530554764233-e79e16c91d08?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTI0fHxtYWhhcmFzaHRyaWFuJTIwZm9vZHxlbnwwfHwwfHx8MA%3D%3D"
                        className="w-100 shadow-1-strong rounded mb-4"
                        alt="Yosemite National Park"
                    />
                </div>
            </div>
        </div>
        </>
    );
};

export default Home;
