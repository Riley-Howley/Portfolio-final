const tl = gsap.timeline({ defaults: { ease: "power1.out" } });

tl.to(".text-a", { y: "0%", duration: 1, stagger: 0.25 });
tl.to(".diff", { y: "0%", duration: 1} , "-=1");
tl.to(".slider", { y: "-100%", duration: 1.5, delay: 0.5 });
tl.to(".intro-a", { y: "-100%", duration: 1 }, "-=1");
tl.fromTo("nav", { opacity: 0 }, { opacity: 1, duration: 1 });
tl.fromTo(".intro", { x: "-1000%" }, { x: "0%", duration: 1 }, "-=1.5");
tl.fromTo(".big-text", { opacity: 0 }, { opacity: 1, duration: 1 }, "-=1");
tl.fromTo(".buttons", { opacity: 0 }, { opacity: 1, duration: 0.5 }, "-=1");


