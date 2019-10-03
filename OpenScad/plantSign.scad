include <triangle.scad>;

nutX = 10;
nutY = 10;
nutZ = 5.5;

boltZ = 10;
boltRad = 6.1/2;
boltHeadZ = 4.9;
boltHeadClearance = 25;
boltHeadRad = 12/2;

stakeX = 160;
stakeY = 20;
stakeZ = stakeY;

spikeLen = 60; 

labelX = 97.55;
labelY = 63.5;
labelZ = 1.35;

labelAngle = 45;

blockThickness = nutZ + 2;
margin = 5;

translate([stakeY, 0, 0]) {
    
//stake();

labelBlock();

//rotate([0,0,-labelAngle])
//translate([-stakeY/2-blockThickness-labelZ,0,stakeZ/2])
//rotate([0,-90,0])
//labelBlock();
}

globalFn = 20;

module stake()
{
    rotate([90,0,0])
    difference()
    {
        union(){
            angledTop();
            stakeBase();
            translate([stakeX, 0, stakeY/2]) {
                spike();
            }
        }
        translate([0,0,stakeZ/2])
        {
            rotate([0,0,labelAngle])
            rotate([0,0,-90])
            translate([-boltHeadZ,0,0])
            rotate([0,90,0])
            bolt();
    }}
}

module spike()
{
    intersection(){
    rotate([0, 90, 0]) {
        cylinder(r1 = stakeY, r2 = 0, h = spikeLen);
    }
    translate([0,0,-stakeZ/2])
    cube([spikeLen, stakeY,stakeZ]);
    }
}

module stakeBase()
{
    cube([stakeX,stakeY,stakeZ]);
}

module angledTop()
{
    scale([-1,1,1])
    linear_extrude(stakeZ)
    {
        rightTriangleByAdjacentAndAngle(stakeY, labelAngle);
    }
}

module bolt()
{
    translate([0,0,-boltZ/2-boltHeadZ]){
        cylinder(h=boltZ, r = boltRad, center=true, $fn = globalFn);
        translate([0,0,boltZ/2])
        cylinder(h=boltHeadClearance, r = boltHeadRad, $fn = globalFn);
    }
}

module labelBlock()
{
    difference(){
        cube([labelX+margin,labelY+margin,blockThickness], center = true);
        translate([0,0,blockThickness/2-labelZ/2])
            labelFootprint();
        translate([-nutX/2,-nutY/2,blockThickness/2-labelZ-nutZ+.02])
            nut();
        cylinder(h=boltZ*2, r = boltRad, center=true, $fn = globalFn);
        
    }
}

module labelFootprint()
{
    cube([labelX,labelY,labelZ+.1],center = true);
}

module nut()
{
    cube([nutX,nutY,nutZ]);
}
